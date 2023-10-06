class Solution:

    ALICE_COLOR = 'A'
    BOB_COLOR = 'B'

    def winnerOfGame(self, colors: str) -> bool:
        listBeforeMove = colors
        for iterationNum in range(1, len(colors)):
            if self._isAliceMove(iterationNum):
                listAfterMove = self._makeMove(listBeforeMove, self.ALICE_COLOR)
                if listAfterMove == listBeforeMove:
                    return False
                else: listBeforeMove = listAfterMove
            else: 
                listAfterMove = self._makeMove(listBeforeMove, self.BOB_COLOR)
                if listAfterMove == listBeforeMove:
                    return True
                else: listBeforeMove = listAfterMove

    def _isAliceMove(self, moveNumber) -> bool:
        return moveNumber % 2 != 0

    def _makeMove(self, colors: str, query: str):
        colorsAfterReplace = colors
        occurences = self._find_symbol_occurences(colors, query)
        if occurences and occurences[0] < len(colorsAfterReplace) - 2:
            for occurency in occurences:
                if occurency + 1 in occurences and occurency + 2 in occurences:
                    colorsAfterReplace = colors[:occurency + 1] + colors[occurency + 2:]
                    break
        return colorsAfterReplace
    
    def _find_symbol_occurences(self, colors: str, query: str):
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