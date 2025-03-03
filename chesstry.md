<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chessboard</title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f0f0f0;
        }
        .chessboard {
            display: grid;
            grid-template-columns: repeat(8, 60px);
            grid-template-rows: repeat(8, 60px);
            border: 2px solid black;
        }
        .square {
            width: 60px;
            height: 60px;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 2rem;
        }
        .black {
            background-color: #769656;
        }
        .white {
            background-color: #eeeed2;
        }
        .piece {
            cursor: grab;
        }
    </style>
</head>
<body>
    <div class="chessboard" id="chessboard"></div>
    <script>
        const board = document.getElementById("chessboard");
        const pieces = {
            'rook': '♜', 'knight': '♞', 'bishop': '♝', 'queen': '♛', 'king': '♚', 'pawn': '♟'
        };
        const initialBoard = [
            ['♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜'],
            ['♟', '♟', '♟', '♟', '♟', '♟', '♟', '♟'],
            ['', '', '', '', '', '', '', ''],
            ['', '', '', '', '', '', '', ''],
            ['', '', '', '', '', '', '', ''],
            ['', '', '', '', '', '', '', ''],
            ['♙', '♙', '♙', '♙', '♙', '♙', '♙', '♙'],
            ['♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖']
        ];
        
        function createBoard() {
            for (let row = 0; row < 8; row++) {
                for (let col = 0; col < 8; col++) {
                    let square = document.createElement("div");
                    square.className = `square ${(row + col) % 2 === 0 ? 'white' : 'black'}`;
                    square.dataset.row = row;
                    square.dataset.col = col;
                    
                    let piece = initialBoard[row][col];
                    if (piece) {
                        let pieceElem = document.createElement("span");
                        pieceElem.textContent = piece;
                        pieceElem.className = "piece";
                        pieceElem.draggable = true;
                        pieceElem.addEventListener("dragstart", dragStart);
                        square.appendChild(pieceElem);
                    }
                    
                    square.addEventListener("dragover", dragOver);
                    square.addEventListener("drop", drop);
                    board.appendChild(square);
                }
            }
        }
        
        let draggedPiece = null;
        function dragStart(event) {
            draggedPiece = event.target;
        }
        function dragOver(event) {
            event.preventDefault();
        }
        function drop(event) {
            event.preventDefault();
            if (draggedPiece && event.target.classList.contains("square")) {
                event.target.innerHTML = "";
                event.target.appendChild(draggedPiece);
            }
        }
        
        createBoard();
    </script>
</body>
</html>
