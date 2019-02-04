namespace GameLogics

module Logics =
    type GameState = { score : int }

    let addScore state scoreInc = 
        match scoreInc with
            | inc when inc >= 0 -> Some { score = state.score + scoreInc }
            | _ -> None
