from network import *

def yolo(*args):
    print('on_response', args)

network = Network(yolo)
network.send_message("moeke")
