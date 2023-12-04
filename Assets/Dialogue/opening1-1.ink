INCLUDE global.ink

{dialogueIndex > 1 : -> END | -> main1}

=== main1 ===
欢迎来到重启人生心理咨询中心。#speaker:旁白
+ [Next]
    -> main2

=== main2 ===
选择一个记忆，记忆是身份的原始材料，它可以像刚刚进行过的对话那样近在咫尺，或者像头皮下的潜意识那样遥远。。
+ [Next]
    ~ dialogueIndex += 1
    -> END
+ [Back]
    -> main1