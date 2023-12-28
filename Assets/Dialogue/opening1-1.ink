INCLUDE global.ink

{dialogueIndex > 1 : -> END | -> main1}

=== main1 ===
欢迎来到重启人生心理咨询中心。#speaker:旁白
+ [Next]
    -> main2

=== main2 ===
记忆是身份的原始材料，选择一个记忆，它可以像你今天吃的早餐那样近在咫尺，也可以像你上幼儿园的第一天那样遥远。重要的是你能真正想象出它的样子。在你的脑海中保持这个记忆。
+ [Next]
    ~ dialogueIndex += 1
    -> END
+ [Back]
    -> main1