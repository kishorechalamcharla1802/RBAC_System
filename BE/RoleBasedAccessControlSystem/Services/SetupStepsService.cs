using RoleBasedAccessControlSystem.Models;
using System.Text.Json;

namespace RoleBasedAccessControlSystem.Services
{
    public class SetupStepsService : ISetupStepsService
    {
        private readonly string _filePath = "setupSteps.json";

        public List<SetupStep> GetAllSetupSteps()
        {
            if (!File.Exists(_filePath)) return new List<SetupStep>();

            var json = File.ReadAllText(_filePath);
            var stepsList = JsonSerializer.Deserialize<List<SetupStep>>(json) ?? new List<SetupStep>();
            return stepsList;
        }

        public void AddSetupStep(SetupStep setupStep)
        {
            if (setupStep == null) throw new ArgumentNullException(nameof(setupStep), "Request body cannot be null.");
            var steps = GetAllSetupSteps();
            setupStep.StepNo = steps.Count > 0 ? steps.Max(u => u.StepNo) + 1 : 1;
            steps.Add(setupStep);
            SaveSteps(steps);
        }

        public void UpdateSetupStep(SetupStep setupStep)
        {
            var steps = GetAllSetupSteps();
            SetupStep? existingStep = steps.FirstOrDefault(u => u.StepNo == setupStep.StepNo);
            if (existingStep != null)
            {
                existingStep.Description = setupStep.Description;
                existingStep.Command = setupStep.Command;
                SaveSteps(steps);
            }
            else
            {
                throw new KeyNotFoundException($"Setup step with ID {setupStep.StepNo} not found.");
            }
        }

        public void DeleteSetupStep(int setupStepNo)
        {
            var steps = GetAllSetupSteps();
            SetupStep? existingStep = steps.FirstOrDefault(u => u.StepNo == setupStepNo);
            if (existingStep != null)
            {
                steps.Remove(existingStep);
                SaveSteps(steps);
            }
            else
            {
                throw new KeyNotFoundException($"Setup step with ID {setupStepNo} not found.");
            }
        }

  
        private void SaveSteps(List<SetupStep> steps)
        {
            var json = JsonSerializer.Serialize(steps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
