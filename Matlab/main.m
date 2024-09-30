%% Pick up object (1st level)
clc;
clear all;
close all;
name = "Matlab";
Client = TCPInit('127.0.0.1',55001,name);

x12 = 0.003149271;
x34 = 0.01046109;
x45 = 0.002309561;
x56 = 0.001784801;
x67 = 0.002521276;

y12 = 0.003704821;
y23 = 0.01074261;
y34 = 0.002252567;

gripping_point = x45 + x56 + x67;

L(1) = Revolute('d',y12,'a',x12,'alpha',pi/2);
L(2) = Revolute('d',0,'a',y23,'alpha',0);
L(3) = Revolute('d',0,'a',y34,'alpha',pi/2);
L(4) = Revolute('d',x34,'a',0,'alpha',-pi/2);
L(5) = Revolute('d',0,'a',0,'alpha',pi/2);
L(6) = Revolute('d',gripping_point,'a',0,'alpha', 0);

robot = SerialLink(L);
joints = [0,pi/2,0,0,0,0];
%robot.plot(joints);

grab = 2; % activate EE (0 - release the object, 1 - grab, 2 - do nothing)
t = [0:0.1:2];

X1 = 0.01713025; % - X
Y1 = 0.002; % - Z 
Z1 = 0.005198001; % - Y


T = transl(X1, Y1, Z1) * trotx(180);
qi1 = robot.ikine(T);
qf1 = [0 pi/2 0 0 0 0];
q = jtraj(qf1,qi1,t);
%robot.plot(q);


b = 1;
for a = 1 : length(q)
    func_data_old(Client, q, grab, b);
    b=b+1;     
end


% take object
grab = 1;
func_data_old(Client, q, grab, b-1);
pause(4.5);

% back to initial pos
grab = 2;
b = 1;
q = jtraj(qi1,qf1,t);
%robot.plot(q);
for a = 1 : length(q)
    func_data_old(Client, q, grab, b); 
    b=b+1;
end

% release object
grab = 0;
func_data_old(Client, q, grab, b-1);

%k1 = 0.002;
%k2 = 0.001;
%k3 = 0.0015;

%Close Gracefully
fprintf(1,"Disconnected from server\n");