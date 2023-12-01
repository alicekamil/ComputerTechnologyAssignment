# ComputerTechnologyAssignment

## How the implementation makes efficient use of computer hardware

I first used an OOP approach which encapsulates data and behavior. By migrating most of my project to DOTS, I separated the data and implementations into the ECS architectural pattern; Entities, Components and systems. By doing so, I can store the entities as contigious data in memory and therefore reduce cache misses and minimizes memory access latency, instead of handling my entities as whole objects with different(or similar)functionality that is scattered all around in memory. You prevent cyclic references and can iterate over objects that actually has a certain component, which enables the systems, that now only handles logic, to process entitites concurrently, taking full advantage of multi-core processors. Furthermore, making it modular like this enables the system to focus on specific components and exclude unneccessary computations.

Furthermore, I migrated my input from checking in the tick to an event driven way thanks to the new input system.

* Custom AABB checking instead of using phsyics/collision
* Removed impl with unitys tag system to the more convenient ECS approach.


## How the implementation uses a data-oriented method

ECS architecture:

* Both player and the asteroids has componentdata(speed, inputs) with their separate tags.
* Systems operate on those components; movement, input, collision etc. Theres also pure game systems that handles spawning and randomization of the spawning.
  
