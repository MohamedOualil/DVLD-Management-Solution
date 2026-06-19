using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public ErrorResponse? Error { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

    }
}
