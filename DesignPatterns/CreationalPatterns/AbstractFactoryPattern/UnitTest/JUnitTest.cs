﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTest
{
    public class JUnitTest : IUnitTest
    {
        public string GetName()
        {
            return "JUnitTest";
        }
    }
}
