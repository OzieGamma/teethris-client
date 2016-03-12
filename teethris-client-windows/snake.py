import game

class Snake:

	def __init__(self, key, friend):
		self.keys = []
		self.keys.append(key)
		self.friend = friend
		teethris.setLighting(key, 0, self.friend*100, self.friend*100)

	def get_keys(self):
		return self.keys

	def get_head(self):
		return self.keys[0]

	def checkIfNeighbour(self,key):
		if not key in self.keys:
			if not key in game.keyboard[self.get_head()]:
				return true
		return false

	def addKey(self,key):
		self.keys.append(key)
		teethris.setLighting(key, 0, self.friend*100, self.friend*100)


