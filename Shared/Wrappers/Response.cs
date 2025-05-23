﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; protected set; }
        public T Data { get; protected set; }
        public string Message { get; protected set; }
        public List<string> Errors { get; set; }

        public static Response<T> Success()
        {
            var result = new Response<T>
            {
                Succeeded = true
            };
            return result;
        }
        public static Response<T> Success(string message)
        {
            var result = new Response<T>
            {
                Succeeded = true,
                Message = message
            };
            return result;
        }

        public static Response<T> Success(T data, string message)
        {
            var result = new Response<T>
            {
                Succeeded = true,
                Data = data,
                Message = message
            };
            return result;
        }

        public static Response<T> Fail()
        {
            var result = new Response<T>
            {
                Succeeded = false
            };
            return result;
        }

        public static Response<T> Fail(string message)
        {
            var result = new Response<T>
            {
                Succeeded = false,
                Message = message
            };
            return result;
        }

        public static Response<T> Fail(string message, List<string> errors)
        {
            var result = new Response<T>
            {
                Succeeded = false,
                Message = message,
                Errors = errors
            };
            return result;
        }

        public static Response<T> Fail(List<string> errors)
        {
            var result = new Response<T>
            {
                Succeeded = false,
                Errors = errors
            };
            return result;
        }
    }
}
