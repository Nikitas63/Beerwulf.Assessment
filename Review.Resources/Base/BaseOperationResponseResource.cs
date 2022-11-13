using System.Collections.Generic;

namespace Review.Resources.Base
{
    public class BaseOperationResponseResource
    {   
        public IEnumerable<ErrorResource> Errors { get; set; }
    }
}