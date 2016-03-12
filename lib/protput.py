from socketIO_client import SocketIO, LoggingNamespace

def on_bbb_response(*args):
    print "yolo"
    print('on_bbb_response', args)

with SocketIO('borisjeltsin.azurewebsites.net', 80, LoggingNamespace) as socketIO:
    socketIO.on('chat message', on_bbb_response)
    socketIO.emit('chat message', 'protput', on_bbb_response)
    socketIO.wait_for_callbacks(seconds=20)
