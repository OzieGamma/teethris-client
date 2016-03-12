from socketIO_client import SocketIO, LoggingNamespace

class Network:
    def __init__(self, incomming_message_callback):
        self.socketIO = SocketIO('borisjeltsin.azurewebsites.net', 80, LoggingNamespace)
        self._register_message_callback(incomming_message_callback)

    def _register_message_callback(self, callback):
        self.socketIO.on('chat message', callback)

    def send_message(self, message):
        self.socketIO.emit('chat message', message)




