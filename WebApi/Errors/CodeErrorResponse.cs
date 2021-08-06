using System;


namespace WebApi.Errors
{ 
public class CodeErrorResponse
{
      public CodeErrorResponse(int statusCode, string message = null)
      {
         StatusCode = statusCode;
         Message = message ?? GetDefaultMessageStatusCode(statusCode);
      }

      private string GetDefaultMessageStatusCode(int statusCode)
      {
         return statusCode switch
         {
            400 => "El request enviado tiene errores",
            401 => "Sin autorizacion para este recurso",
            404 => "Recurso no encontrado",
            500 => "Se produjo un error de servidor", => null
         };
      }
      public int StatusCode { get; set; }
      public string Message { get; set; }
   }
}