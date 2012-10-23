using Machine.Specifications;

namespace UseCaseMakerLibrary.Tests.UseCaseTests
{
    [Subject(typeof(UseCase))]
    public class When_adding_a_default_step_after_an_alternative_child_step : UseCaseTestBase
    {
        private Establish Context = () =>
            {
                UseCase.AddStep(null, Step.StepType.AlternativeChild, "", null, DependencyItem.ReferenceType.None);
                _previousStep = (Step)UseCase.Steps[0];
                _previousStep.Type = Step.StepType.AlternativeChild;
                _previousStep.Prefix = "A";
                _previousStep.ChildID = 0;
            };

        private Because Of = () => StepIndex = UseCase.AddStep(
            _previousStep, Step.StepType.Default, Stereotype, OtherUseCase, DependencyItem.ReferenceType.Client);

        private It Should_add_step_to_use_case = () => UseCase.Steps.Count.ShouldEqual(2);

        private It Should_set_type_to_alternative_child =
            () => ((Step)UseCase.Steps[StepIndex]).Type.ShouldEqual(Step.StepType.AlternativeChild);

        private It Should_set_prefix_to_a = () => ((Step)UseCase.Steps[StepIndex]).Prefix.ShouldEqual("A");

        private It Should_set_child_id_to_one = () => ((Step)UseCase.Steps[StepIndex]).ChildID.ShouldEqual(1);

        private It Should_insert_case_at_end_of_steps = () => StepIndex.ShouldEqual(1);

        private Behaves_like<StepCreationBehavior> a_step_creator; 
        
        private static Step _previousStep;
    }
}