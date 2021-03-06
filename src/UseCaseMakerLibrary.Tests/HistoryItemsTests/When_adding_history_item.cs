using Machine.Specifications;

namespace UseCaseMakerLibrary.Tests.HistoryItemsTests
{
    [Subject(typeof(HistoryItems))]
    public class When_adding_history_item : HistoryItemsTestBase
    {
        private Establish Context = () => { _newHistoryItem = new HistoryItem(); };

        private Because Of = () => HistoryItems.Add(_newHistoryItem);

        private It Should_contain_new_item = () => HistoryItems.ShouldContain(_newHistoryItem);

        private static HistoryItem _newHistoryItem;
    }
}