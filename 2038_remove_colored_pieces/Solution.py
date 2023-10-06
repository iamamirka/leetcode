class Solution:

    ALICE_COLOR = 'AAA'
    BOB_COLOR = 'BBB'

    def winnerOfGame(self, colors: str) -> bool:
        alices_occurences = self._find_symbol_occurrences(colors, self.ALICE_COLOR)
        bobs_occurences = self._find_symbol_occurrences(colors, self.BOB_COLOR)
        if not alices_occurences:
            return False
        if not bobs_occurences:
            return True
        if len(alices_occurences) > len(bobs_occurences):
            return True
        else:
            return False
    
    def _find_symbol_occurrences(self, colors: str, query: str):
        iterationNum = 0
        occurencyIndex = 0
        occurences = []
        while(iterationNum < len(colors)):
            occurencyIndex = colors.find(query, iterationNum)
            if occurencyIndex != -1:
                occurences.append(occurencyIndex)
                iterationNum = occurencyIndex
            iterationNum += 1
        return occurences