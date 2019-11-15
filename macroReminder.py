import winsound
import time


def mainFunc():
	
	start = time.time()
	print("hello")

	while True:
		cur = time.time()
		if cur - start > 5:
#			winsound.PlaySound('Alarm-tone_short.wav', winsound.SND_FILENAME)
			winsound.PlaySound('media.io_reminder.wav', winsound.SND_FILENAME)
			start = time.time()

if __name__ == "__main__":
	print ("Welcome to macroReminder")
	mainFunc()