using STW.UNSK.Personal.Model;
using System.Collections.Generic;
using System.Linq;

namespace PersonalEditor
{
    public class WorkerEditorVM:PersonEditorVM 
    {
        
        public WorkerEditorVM(Worker worker, ICollection<Post> avaliablePosts):base(worker,avaliablePosts)
        {
            Worker = worker;
        }

        public Worker Worker { get; set; }

        public int Rank
        {
            get { return Worker.Rank; }
            set { Worker.Rank = value; }
        }



    }
}