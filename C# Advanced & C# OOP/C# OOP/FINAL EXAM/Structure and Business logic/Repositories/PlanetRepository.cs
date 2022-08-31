﻿namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models => (List<IPlanet>)models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name)
        {
            IPlanet planetToFind = this.models.FirstOrDefault(x => x.Name == name);
            if (planetToFind != null)
            {
                return planetToFind;
            }

            return null;
        }

        public bool RemoveItem(string name)
        {
            IPlanet planetToRemove = this.models.FirstOrDefault(x => x.Name == name);
            if (planetToRemove != null)
            {
                this.models.Remove(planetToRemove);
                return true;
            }

            return false;
        }
    }
}
