using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object key)
            : base($"\"{entityName}\" tapılmadı. Key: {key}") { }
    }

    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException(string message = "Bu əməliyyatı etməyə icazəniz yoxdur.")
            : base(message) { }
    }

    public class InvalidVoteValueException : Exception
    {
        public InvalidVoteValueException()
            : base("Vote dəyəri yalnız +1 (upvote) və ya -1 (downvote) ola bilər.") { }
    }
}
