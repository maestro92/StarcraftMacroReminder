import winsound
import time
from PIL import Image
import pygame
from pygame.locals import *
import threading

'''
def soundFunc():


    while True:
        if(music):
            # pygame.mixer.music.load('media.io_reminder.wav')
            #pygame.mixer.music.play(0)
            winsound.PlaySound('media.io_reminder.wav', winsound.SND_FILENAME)
            music = False
        # time.sleep(3)
'''
def mainFunc():
    
    pygame.init()


    screen = pygame.display.set_mode([1280, 800], 0, 32)
    #initiates screen

#    sound = pygame.mixer.Sound('media.io_reminder.wav')
    start = time.time()
    # imageStart = time.time()
    global displaying
    global music

    displaying = False 
    music = False

    # sound_thread = threading.Thread(target = soundFunc)
    #sound_thread.start()

    while True:
        for event in pygame.event.get():
            if event.type == QUIT:
                exit()
        cur = time.time()
        if cur - start > 5:
#           winsound.PlaySound('Alarm-tone_short.wav', winsound.SND_FILENAME)
            winsound.PlaySound('media.io_reminder.wav', winsound.SND_FILENAME | winsound.SND_ASYNC | winsound.SND_ALIAS)
            
#            sound.play()
#           winsound.PlaySound('1_second_tone.wav', winsound.SND_FILENAME)
#            image.show()



            music = True
            displaying = True
            start = time.time()


        if displaying:
            if cur - start > 0.1:
                displaying = False


        screen.fill([255, 255, 255])
        #screen is filled with a black background

        if(displaying):
            screen.fill([255, 0, 0])
            #screen.blit(image1, [0, 0]) 
            #here image1 is blitted onto screen at the coordinates (200,200)

        #image1.blit(image2, [0, 0])
        #here image2 is blitted onto image1 at the coordinates (0,0) which starts at the upper left of image1

        pygame.display.update()
        pygame.time.Clock().tick(60)
        #updates display, which you can just ignore
"""

    start = time.time()
    imageStart = time.time()

    image = Image.open('scv_and_depo_red.png')
    blankImage = Image.open('blank.png')
    blankImage.show()
    print("hello")
    displaying = False


    while True:
        cur = time.time()

        if cur - start > 5:
#           winsound.PlaySound('Alarm-tone_short.wav', winsound.SND_FILENAME)
            winsound.PlaySound('media.io_reminder.wav', winsound.SND_FILENAME)

#           winsound.PlaySound('1_second_tone.wav', winsound.SND_FILENAME)
            image.show()
            displaying = True

            start = time.time()

        if displaying:
            if cur - imageStart > 1:
                displaying = False

"""
if __name__ == "__main__":
    print ("Welcome to macroReminder")
    mainFunc()