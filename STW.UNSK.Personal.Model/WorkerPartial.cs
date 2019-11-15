using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STW.UNSK.Personal.Model
{
    partial class Worker
    {
        public override PostCategory Category => PostCategory.Worker;

        public override void Update(Person person)
        {
            base.Update(person);
            Rank = ((Worker)person).Rank;
        }
    }
}
