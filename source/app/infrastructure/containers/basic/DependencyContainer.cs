﻿using System;

namespace app.infrastructure.containers.basic
{
  public class DependencyContainer :IFetchDependencies
  {
    IFindDependencyFactories dependency_finder;

      public DependencyContainer(IFindDependencyFactories dependency_finder)
      {
          this.dependency_finder = dependency_finder;
      }

      public Dependency a<Dependency>()
      {
          try
          {
return (Dependency) dependency_finder.get_factory_that_can_create(typeof(Dependency)).create();
          }
          catch (Exception exception)
          {
              DependencyCreationException ex = new DependencyCreationException("",exception, typeof(Dependency));
              throw ex;
          }
          
      }
  }
}