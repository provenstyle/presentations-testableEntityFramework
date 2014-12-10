using Data.Queries;
using Highway.Data;
using Highway.Data.EntityFramework;
using Machine.Specifications;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToLambdaExpression
namespace DataTestsMspec
{
    public class when_getting_all_talks
    {
        Establish context = () =>
        {
            _dataContext = Helper.RealDataContext();
            _query = new AllTalks();
        };

        It should_be_performant = () =>
        {
            _query.RunPerformanceTest(_dataContext, false, 50);
        };

        static AllTalks _query;
        static IDataContext _dataContext;
    }
}