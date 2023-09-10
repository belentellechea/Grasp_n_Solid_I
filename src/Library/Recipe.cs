//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe  
    //pasos para la receta
    {
        private ArrayList steps = new ArrayList();  //lista con todos los pasos 

        public Product FinalProduct { get; set; } 

        public void AddStep(Step step)  //agregar pasos 
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)  //eliminar pasos 
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()  //impresión de la receta final 
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        public double GetProductionCost()  
         //método añadido para calcular el costo total de producción 
        {
            double totalSupplies = 0.0;
            double totalEquipment = 0.0;
            foreach (Step step in this.steps)
            {
                totalSupplies += step.Input.UnitCost;
                totalEquipment += step.Equipment.HourlyCost*(step.Time/60.0);
            }
            double totalCost = totalSupplies + totalEquipment;
            return totalCost;
        }
    }
}

/*
Para la realización de esta consigna se vió implementado el principio Expert, 
ya que la clase "Recipe" era la única que tenía la información necesaria para 
poder cumplir con la responsabilidad de realizar el cálculo del costo total de
producción. 
*/