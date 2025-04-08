# [IEC 60870 5 part 104 Protocol RTU IED Server Simulator](http://www.freyrscada.com/iec-60870-5-104-Server-Simulator.php)


Complete Simulation of IEC 104 Server as per Protocol Standard including File transfer (Both Monitoring and control direction).

[![IEC 60870-5-104 Protocol RTU IED Server Simulator](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec104-server-sim.jpg)](http://www.freyrscada.com/iec-60870-5-104-Server-Simulator.php)


​Support all type of ASDU Typeid according to protocol specification

1) Monitoring (Process information in monitor direction), M_SP. M_DP, M_ST,...

2) control (Process information in control direction), C_SC, C_DC, ...

3) System information in monitor direction, M_EI

4) System information in control direction C_IC, C_CI

5) Parameter in control direction, P_ME

6) File transfer ( Both Monitor And Control Direction) F_FR, F_SR, F_SC



IEC 104 Server Simulator developed to test the functionalities of IEC 60870-5-104 stack Source code Library - server Operation.

We can add up to 50 server node in the simulator. Every server node will work independently.

Simulator window shows the status & connection ip address, port number, redundancy enabled or not, If Redundancy enabled it shows, the redundant source ip address, port .

The user can update the monitoring Point information. The following parameters can change Value and quality bits.


## Features

 - Multiple Server Simulation

 - In a Single Server(link) simulate Multiple Stations (Common Address)

 - Redundancy Enabled

 - Mapping of Control Point to monitor Information point, consider C_SC point can map to M_SP point

 - Communication with redundant control systems and interruption-free switchover between redundant systems

 - Supports "select-before-operate" or "direct-execute" command execution modes

 - supports File Transfer ( Both Monitor And Control Direction), Directory commands

 - Clock synchronization, General Interrogation, counter interrogation,

 - On-demand transmission (e. g. single indications, analogs...)

 - Spontaneous transmission (e. g. single indications with time tag ...)

 - parameter activation commands
 
 - One-time payment, royalty-free 

 - Neither license manager nor dongle required.
	


## Knowledge Base


[IEC 60870-5-104 Protocol Server Interoperability](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Interoperability.pdf)

[IEC 60870-5-104 Protocol RTU Server Simulator User Manual](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Simulator-User-Manual.pdf)



## [Download Evaluation Kit - IEC 104 Protocol Development Bundle](http://www.freyrscada.com/iec-60870-5-104.php#Download-IEC60870-5-104-Development-Bundle)

In the Development Bundle, We included IEC 60870-5 part 104 Protocol Server  Client Simulator, Windows and Linux SDK, C# projects, Doxygen documentation and Raspberry Pi, BeagleBone Demo library.