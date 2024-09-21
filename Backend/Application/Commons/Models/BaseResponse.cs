using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }    
        public string Message { get; set; }   
        public T? Data { get; set; } 

        //CONSTRUCTOR DE RESPUESTA EXITOSA
        public BaseResponse(T data)
        {
            Success = true;                
            Message = string.Empty;            
            Data = data;                        
        }

        //CONSTRUCTOR DE RESPUESTA FALLIDA
        public BaseResponse(string message)
        {
            Success = false;                   
            Message = message;                
            Data = default;               
        }
    }
}