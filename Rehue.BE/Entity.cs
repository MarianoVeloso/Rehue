﻿using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Entity : IEntity
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
