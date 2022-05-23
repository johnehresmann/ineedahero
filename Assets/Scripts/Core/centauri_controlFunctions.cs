using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IPlatformerControls<S,T> {
    void PlayerMove(S speed,T jump);
    void PlayerJump(S jumpForce, T airControl);

    }