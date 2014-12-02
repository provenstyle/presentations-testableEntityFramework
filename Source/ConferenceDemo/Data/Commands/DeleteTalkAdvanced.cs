using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Highway.Data;

namespace Data.Commands
{
    public class DeleteTalkAdvanced : AdvancedCommand
    {
        public DeleteTalkAdvanced(int id)
        {
            ContextQuery = c => 
                c.ExecuteSqlCommand("delete from talks where id = @id", new SqlParameter("@id", id));
        }
    }
}
