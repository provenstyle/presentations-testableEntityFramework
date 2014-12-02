using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Highway.Data;

namespace Data.Commands
{
    public class DeleteTalk : Command
    {
        public DeleteTalk(int id)
        {
            ContextQuery = c =>
            {
                var talk = c.AsQueryable<Talk>().FirstOrDefault(x => x.Id == id);
                c.Remove(talk);
                c.Commit();
            };
        }
    }
}
