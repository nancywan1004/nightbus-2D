INCLUDE global.ink

{ dialogueIndex > 2 : -> END | -> main1}

=== main1 ===
喝下去，然后在脑海中保持这个记忆。#speaker:旁白
+ [Next]
    -> main2

=== main2 ===
欢迎。请在此处耐心等待。
+ [Next]
    ~ dialogueIndex += 1
    -> END
+ [Back]
    -> main1
