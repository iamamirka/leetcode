from Solution import Solution
import pytest

class TestSolution:
    colors_cases = [("AAABABB",True),
                     ("AA",False),
                     ("ABBBBBBBAAA",False),
                     ("AAAAABBBBBBAAAAA",True),
                     ("AAAAABBB",True)
                     ]
    
    @pytest.mark.parametrize(("colors", "expected"), colors_cases)
    def test_winnerOfGame(self, colors: str, expected : bool):
        solution = Solution()
        actual = solution.winnerOfGame(colors)
        assert actual == expected

    if __name__ == "__main__":
        pytest.main([__file__])