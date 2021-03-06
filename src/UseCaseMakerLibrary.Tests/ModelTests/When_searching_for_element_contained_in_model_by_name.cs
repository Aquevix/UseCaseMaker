using Machine.Specifications;
using UMMO.TestingUtils;

namespace UseCaseMakerLibrary.Tests.ModelTests
{
    [Subject(typeof (Model))]
    public class When_searching_for_element_contained_in_model_by_name : ModelTestBase
    {
        private Because Of = () =>
                                 {
                                     _glossaryName = A.Random.String;
                                     _element = new GlossaryItem {Name = _glossaryName};
                                     Model.AddGlossaryItem(_element);
                                 };

        private It Should_return_the_element = () => Model.FindElementByName(_glossaryName).ShouldEqual(_element);
        

        private static string _glossaryName;
        private static GlossaryItem _element;
    }
}