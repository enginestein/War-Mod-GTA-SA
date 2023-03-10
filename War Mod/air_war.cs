{$CLEO .cs}

Thread "WAR"

:WAR_50
wait 500
if and
$WAR_WarStatus == 1
player.Defined($Player_Char)
jf @WAR_50
model.Load(520)
model.Load(287)
038B: load_requested_models
if and
model.Available(520)                                               
model.Available(287)                          
jf @WAR_100

:WAR_100
wait 0
if
0819: 31@ = actor $PLAYER_ACTOR distance_from_ground
if and
actor.DrivingPlane($PLAYER_ACTOR)
31@ >= 110.0
jf @WAR_100
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_100
if
056E:   car 0@(30@,5i) defined
jf @WAR_200
if 
0205:   actor $PLAYER_ACTOR near_car 0@(30@,5i) radius 350.0 350.0 350.0 flag 0
jf @WAR_150
0227: 21@ = car 0@(30@,5i) health
if
21@ <= 10
jf @WAR_300
actor.DestroyInstantly(4@(30@,5i))
car.RemoveReferences(0@(30@,5i))
0@(30@,5i) = 0
jump @WAR_200

:WAR_150
actor.DestroyInstantly(4@(30@,5i))
car.Destroy(0@(30@,5i))
0@(30@,5i) = 0
jump @WAR_200

:WAR_200
if
30@ <= 4
jf @WAR_300
0208: 21@ = random_float_in_ranges -200.0 200.0
0208: 22@ = random_float_in_ranges -200.0 290.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 31@  
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 31@  
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 100.0 100.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 300.0 300.0
jf @WAR_300
00A5: 0@(30@,5i) = create_car 520 at 21@ 22@ 23@
0129: 4@(30@,5i) = create_actor_pedtype 7 model 287 in_car 0@(30@,5i) driverseat
070E: hydra 0@(30@,5i) attack_player_car $PLAYER_CHAR radius 20.0
04BA: set_car 0@(30@,5i) speed_to 50.0
jump @WAR_300

:WAR_300
30@ += 1
if
30@ >= 5
jf @WAR_100
30@ = 0
jump @WAR_100

:WAR_1000
30@ = 0

:WAR_1050
if
056E:   car 0@(30@,5i) defined
jf @WAR_1100
actor.DestroyInstantly(4@(30@,5i))
car.Destroy(0@(30@,5i))
0@(30@,5i) = 0

:WAR_1100
30@ += 1
if
30@ >= 5
jf @WAR_1050
30@ = 0
jump @WAR_100