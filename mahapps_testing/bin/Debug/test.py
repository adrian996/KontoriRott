import serial
import time
import csv

ser = serial.Serial('COM3', 9600)
i=0

while 1:
	time.sleep(2.563)
	f= open("data.txt","w+")
	s = ser.readline().decode()
	data = str(s)
	f.write(data)
	print(s)
	f.close()