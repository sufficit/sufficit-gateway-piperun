using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PipeRun.Responses
{
    public class Response
    {
        ///<summary> 
        ///<para>Indica se houve algum erro de processamento interno no destino</para>
        ///<para>Não se refere ao resultado da consulta</para>
        ///<para>EX: Não indica se o cliente esta conectado</para>
        ///</summary>
        [JsonPropertyName("success")]
        [JsonPropertyOrder(-2)]
        public bool Success { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        [JsonPropertyName("message")]
        [JsonPropertyOrder(-1)]
        public string? Message { get; set; }
    }
}
