using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAplicacion
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
            Success = true;
        }
        public bool Success { get; set; }   
        public T data { get; set; }
        public string message { get; set; }
    }
}
