using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Services
{
    public interface ISetupStepsService
    {
        List<SetupStep> GetAllSetupSteps();
        void AddSetupStep(SetupStep setupStep);
        void UpdateSetupStep(SetupStep setupStep);
        void DeleteSetupStep(int setupStepId);
    }
}
