﻿namespace ExplicitInterfaces.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        void GetName();
    }
}
