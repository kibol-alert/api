﻿using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse() : base(false)
        {
        }
        public ErrorResponse(string message) : base(message, false)
        {
        }
    }
}
