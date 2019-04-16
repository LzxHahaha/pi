#!/usr/bin/python

# DHT11 Temperature-Humidity Sensor

import RPi.GPIO as GPIO
import time

channel = 2 # GPIO channel

def btoi(bit_arr):
    res = 0
    m = min(8, len(bit_arr))
    for i in range(m):
        res += bit_arr[i] * 2 ** (7 - i)
    return res

def get_data():
    data = []
    GPIO.setmode(GPIO.BCM)
    time.sleep(1)
    GPIO.setup(channel, GPIO.OUT)
    GPIO.output(channel, GPIO.LOW)
    time.sleep(0.02)
    GPIO.output(channel, GPIO.HIGH)
    GPIO.setup(channel, GPIO.IN)

    while GPIO.input(channel) == GPIO.LOW:
        continue
    while GPIO.input(channel) == GPIO.HIGH:
        continue
	
    for i in range(40):
        j = 0
        while GPIO.input(channel) == GPIO.LOW:
            continue
        while GPIO.input(channel) == GPIO.HIGH and j <= 100:
            j += 1
        data.append(0 if j < 8 else 1)

    humidity = btoi(data[:8])
    humidity_point = btoi(data[8:16])
    temperature = btoi(data[16:24])
    temperature_point = btoi(data[24:32])
    check = btoi(data[32:])

    GPIO.cleanup()

    return {
        "humidity": humidity,
        "humidity_point": humidity_point,
        "temperature": temperature,
		"temperature_point": temperature_point,
		"check": check
    }


if __name__ == "__main__":
    print get_data()

