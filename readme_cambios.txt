Descripción del GameControler
El name Space se llama Simplon y tiene una clase llamada GameControler
Setea la cantidad de vueltas a la pista por defecto es 3
Mantiene actualizada la velocidad del auto para el HUD
Cuenta las vueltas a la pista

Creación checkpoints
Es un objeto con un box collider y la opción Is Trigger.
Usa el script llamado CheckPointControl, este tiene 3 campos configurables
   bool CheckpointEnter=false; //indica si ya se pasó por ese check Point
   IdCheckPoint=1; //número para identificar checkpoint si hay más de uno
   bool IsGoal=false; //Es la meta si se setea a true 

Si CheckpointEnter es true no se tiene en cuenta el evento OnTriggerEnter del auto 
IdCheckPoint se usa para diferenciar los checkponits
IsGoal indica si el checkpoint es la meta
El checkpoint definido como meta resetea todos los checkpoints si aún no se completó el número de vueltas, también resetea el contador de tiempo

HUD
Esta creado en una escena llamada Hud se carga de forma aditiva.
Muestra el tiempo en cuenta regresiva
Muestra la velocidad
Muestra el total de vueltas y en que vuelta esta



