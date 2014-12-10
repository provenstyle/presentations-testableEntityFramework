using System;
using Data.Queries;
using Highway.Data;
using Machine.Specifications;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToLambdaExpression
namespace DataTestsMspec
{
    public class when_you_need_the_sql_query
    {
        Establish context = () =>
        {
            _dataContext = Helper.RealDataContext();
            _query = new TalksBySpeakerId(7);
        };

        Because of = () =>
        {
            _sql = _query.OutputSQLStatement(_dataContext);
            Console.WriteLine(_sql);
        };

        It can_be_output = () => _sql.IsNullOrEmpty().ShouldBeFalse();
        
        static IDataContext _dataContext;
        static TalksBySpeakerId _query;
        static string _sql;
    }
}