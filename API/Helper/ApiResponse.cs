using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Helper
{
    public class ApiResponse
    {
       public HttpStatusCode statusCode{get;set;}

       public bool IsExitoso { get; set; } =true;

       public List<string> ErrorMesagges { get; set; }

       public object Resultado { get; set; }
       
       
    }
}