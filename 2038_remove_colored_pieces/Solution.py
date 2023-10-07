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
        return False
    
    def _find_symbol_occurrences(self, colors: str, query: str):
        iterationNum = 0
        occurrencyIndex = 0
        occurrences = []
        while(occurrencyIndex != -1):
            occurrencyIndex = colors.find(query, iterationNum)
            if occurrencyIndex != -1:
                occurrences.append(occurrencyIndex)
                iterationNum = occurrencyIndex + 1
        return occurrences