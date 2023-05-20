# writes all 5 letter words to words.txt

with open("words_all.txt", "r") as f:
	with open("words.txt", "w") as w:
		for i in range(10000):
			word = f.readline()
			if len(word) == 6:
				w.writelines(word)