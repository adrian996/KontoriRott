import sys
import time
import serial
import csv

#ser = serial.Serial('COM3', 9600)

i = 500

while 1: 
	f = open("data.txt","w+")
	f.write(str(i%2) + "," + str(i))
	print(str(i%2) + "," + str(i))
	f.close()
	i += 1
	time.sleep(5)


"""
import serial
import time
import csv

#ser = serial.Serial('COM3', 9600)
i=0

while 1: 
    f= open("data.txt","w+")
    s = ser.readline().decode()
    data = str(s)
    f.write(data)
    print(s)
    f.close()
    time.sleep(.300)
"""