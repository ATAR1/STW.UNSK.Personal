using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PersonalEditor
{
    public class PersonEditorVMFactory
    {
        public static PersonEditorVM Generate(Person person, ICollection<Post> avaliablePosts)
        {
            if (person is Engineer)
                return new PersonEditorVM(person, avaliablePosts);
            if (person is Worker)
                return new WorkerEditorVM((Worker)person, avaliablePosts);
            throw new UnknownTypeOfPersonException();
        }
    }

    [Serializable]
    public class UnknownTypeOfPersonException : Exception
    {
        public UnknownTypeOfPersonException()
        {
        }

        public UnknownTypeOfPersonException(string message) : base(message)
        {
        }

        public UnknownTypeOfPersonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownTypeOfPersonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
