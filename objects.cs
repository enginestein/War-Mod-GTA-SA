{$CLEO .cs}

Thread "WAR"

:WAR_1
wait 500
if and
$WAR_WarStatus == 1
player.Defined($PLAYER_CHAR)
jf @WAR_1

:WAR_2
wait 0
model.Load(#BARRACKS)
model.Load(#PATRIOT)
model.Load(964) 
model.Load(3796) 
model.Load(2991) 
model.Load(910) 
model.Load(922) 
model.Load(944) 
model.Load(3066) 
038B: load_requested_models
if and
model.Available(#BARRACKS)
model.Available(#PATRIOT)
model.Available(910) 
model.Available(922) 
jf @WAR_2
if and
model.Available(944) 
model.Available(3066)
model.Available(964) 
model.Available(3796)
model.Available(2991)
jf @WAR_2 
29@ = 0
31@ = 0  
30@ = 0
8@ = 3066
9@ = 944
10@ = 964
11@ = 910
12@ = 922
13@ = 2991
14@ = 3796
jump @WAR_200

:WAR_100
wait 0
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_100
if
03CA:   object 1@(31@,7i) exists
jf @WAR_200
if
8474:   not actor $PLAYER_ACTOR near_object_in_cube 1@(31@,7i) radius 110.0 110.0 120.0 sphere 0
jf @WAR_500
object.Destroy(1@(31@,7i))
jump @WAR_200

:WAR_200
0819: 0@ = actor $PLAYER_ACTOR distance_from_ground
if
0@ <= 100.0
jf @WAR_275
if
31@ <= 6
jf @WAR_250
0208: 21@ = random_float_in_ranges -90.0 90.0
0208: 22@ = random_float_in_ranges -55.0 100.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 0@ = random_float_in_ranges -11.0 11.0
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -11.0 11.0
005B: 22@ += 0@  // (float)
23@ += 10.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if
29@ >= 1
jf @WAR_225
if and
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 100.0 100.0
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 40.0 40.0
jf @WAR_250

:WAR_225
1@(31@,7i) = object.Create(8@(31@,7i), 21@, 22@, 23@)
0208: 0@ = random_float_in_ranges 0.0 359.0
0177: set_object 1@(31@,7i) Z_angle_to 0@
07F7: set_object 1@(31@,7i) destructible 0
if
31@ == 0
jf @WAR_250
object.StorePos(1@(31@,7i), 21@, 22@, 23@)
23@ -= 0.83
object.PutAt(1@(31@,7i), 21@, 22@, 23@)
jump @WAR_250

:WAR_250
if
29@ <= 0
jf @WAR_500
wait 0
31@ += 1
if
31@ >= 7
jf @WAR_200
29@ = 1
jump @WAR_500

:WAR_275
if
29@ == 0
jf @WAR_500
wait 0
0819: 0@ = actor $PLAYER_ACTOR distance_from_ground
if
0@ <= 100.0
jf @WAR_275
jump @WAR_200

:WAR_300
if
$WAR_WarStatus == 1
jf @WAR_1000
if
056E:   car 15@(30@,4i) defined
jf @WAR_400
if
8205:   not actor $PLAYER_ACTOR near_car 15@(30@,4i) radius 110.0 110.0 120.0 flag 0
jf @WAR_600
car.Destroy(15@(30@,4i))
jump @WAR_400

:WAR_400
0819: 0@ = actor $PLAYER_ACTOR distance_from_ground
if
0@ <= 100.0
jf @WAR_100
if
player.Defined($PLAYER_CHAR)
jf @WAR_100
if
31@ <= 1
jf @WAR_600
8@ = 470
9@ = 433
0208: 21@ = random_float_in_ranges -70.0 70.0
0208: 22@ = random_float_in_ranges -50.0 100.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 0@ = random_float_in_ranges -7.0 7.0
wait 10
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 0@  // (float)
if and
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 100.0 100.0
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 40.0 40.0
jf @WAR_100
15@(30@,4i) = Car.Create(8@(30@,4i), 21@, 22@, 23@)
0208: 0@ = random_float_in_ranges 0.0 359.0
0175: set_car 15@(30@,4i) Z_angle_to 0@
car.SetImmunities(15@(30@,4i), 1, 0, 0, 0, 1)
8@ = 3066
9@ = 944
jump @WAR_600

:WAR_500
31@ += 1
if
31@ >= 7
jf @WAR_300
31@ = 0
jump @WAR_300

:WAR_600
30@ += 1
if
30@ >= 2
jf @WAR_100
30@ = 0
jump @WAR_100

:WAR_1000
30@ = 0
31@ = 0

:WAR_1100
object.Destroy(1@(31@,7i))
31@ += 1
if
31@ >= 7
jf @WAR_1100
jump @WAR_1200

:WAR_1200
if
056E:   car 15@(30@,4i) defined
jf @WAR_1300
car.Destroy(15@(30@,4i))

:WAR_1300
30@ += 1
if
30@ >= 2
jf @WAR_1200
jump @WAR_1










