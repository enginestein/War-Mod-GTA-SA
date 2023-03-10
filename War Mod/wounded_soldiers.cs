{$CLEO .cs}

Thread "WAR"

:WAR_100
wait 500
if and
$WAR_WarStatus == 1
player.Defined($PLAYER_CHAR)
jf @WAR_100
model.Load(285)
model.Load(287)
04ED: load_animation  "SWAT"
04ED: load_animation  "SWEET"
038B: load_requested_models

:WAR_200
wait 0
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_200
if
056D:   actor 0@(30@,4i) defined
jf @WAR_300
if
0104:   actor $PLAYER_ACTOR near_actor 0@(30@,4i) radius 110.0 110.0 120.0 sphere 0
jf @WAR_250
29@ = actor.Health(0@(30@,4i))
if
29@ <= 0
jf @WAR_400
0332: set_actor 0@(30@,5i) bleeding 0
088A: actor 0@(30@,4i) perform_animation "Null" IFP "SWAT" 8.0 loopA 0 lockX 0 lockY 0 lockF 0 time 1 disable_force 0 disable_lockZ 1
actor.RemoveReferences(0@(30@,4i))
jump @WAR_300

:WAR_250
actor.DestroyInstantly(0@(30@,5i))

:WAR_300
0819: 11@ = actor $PLAYER_ACTOR distance_from_ground
if
11@ <= 150.0
jf @WAR_400
if
30@ <= 3
jf @WAR_400
0208: 8@ = random_float_in_ranges -100.0 100.0
0208: 9@ = random_float_in_ranges -50.0 100.0
04C4: store_coords_to 8@ 9@ 10@ from_actor $PLAYER_ACTOR with_offset 8@ 9@ 0.0
02C1: store_to 8@ 9@ 10@ car_path_coords_closest_to 8@ 9@ 10@
0208: 11@ = random_float_in_ranges -8.0 8.0
005B: 8@ += 11@  
0208: 11@ = random_float_in_ranges -8.0 8.0
005B: 9@ += 11@  
if and
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 8@ 9@ radius 70.0 80.0
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 8@ 9@ radius 40.0 40.0
jf @WAR_400
10@ += 10.0
02CE: 10@ = ground_z_at 8@ 9@ 10@
0@(30@,4i) = actor.Create(civmale, 287, 8@, 9@, 10@)
0332: set_actor 0@(30@,5i) bleeding 1
actor.Health(0@(30@,5i)) = 3
0208: 11@ = random_float_in_ranges 0.0 359.0
0173: set_actor 0@(30@,4i) Z_angle_to 11@
if
30@ >= 2
jf @WAR_310
088A: actor 0@(30@,4i) perform_animation "gnstwall_injurd" IFP "SWAT" 8.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 disable_force 0 disable_lockZ 1
jump @WAR_400

:WAR_310
088A: actor 0@(30@,4i) perform_animation "Sweet_injuredloop" IFP "SWEET" 8.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 disable_force 0 disable_lockZ 1

:WAR_400
30@ += 1
if
30@ >= 4
jf @WAR_500
30@ = 0

:WAR_500
if
$WAR_WarStatus == 1
jf @WAR_1000
if
056D:   actor 4@(31@,4i) defined
jf @WAR_600
if
0104:   actor $PLAYER_ACTOR near_actor 4@(31@,4i) radius 70.0 80.0 120.0 sphere 0
jf @WAR_550
29@ = actor.Health(4@(31@,4i))
if
29@ <= 0
jf @WAR_700
0332: set_actor 4@(31@,5i) bleeding 0
088A: actor 4@(31@,4i) perform_animation "Null" IFP "SWAT" 8.0 loopA 0 lockX 0 lockY 0 lockF 0 time 1 disable_force 0 disable_lockZ 1
actor.RemoveReferences(4@(31@,4i))
jump @WAR_600

:WAR_550
actor.DestroyInstantly(4@(31@,5i))

:WAR_600
0819: 11@ = actor $PLAYER_ACTOR distance_from_ground
if
11@ <= 150.0
jf @WAR_700
if
31@ <= 3
jf @WAR_700
0208: 8@ = random_float_in_ranges -100.0 100.0
0208: 9@ = random_float_in_ranges -50.0 100.0
04C4: store_coords_to 8@ 9@ 10@ from_actor $PLAYER_ACTOR with_offset 8@ 9@ 0.0
02C1: store_to 8@ 9@ 10@ car_path_coords_closest_to 8@ 9@ 10@
0208: 11@ = random_float_in_ranges -8.0 8.0
005B: 8@ += 11@
0208: 11@ = random_float_in_ranges -8.0 8.0
005B: 9@ += 11@  
if and
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 8@ 9@ radius 70.0 80.0
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 8@ 9@ radius 40.0 40.0
jf @WAR_700
10@ += 10.0
02CE: 10@ = ground_z_at 8@ 9@ 10@
4@(31@,4i) = actor.Create(civmale, 285, 8@, 9@, 10@)
0332: set_actor 4@(31@,5i) bleeding 1
actor.Health(4@(31@,5i)) = 3
0208: 11@ = random_float_in_ranges 0.0 359.0
0173: set_actor 4@(31@,4i) Z_angle_to 11@
if
31@ >= 2
jf @WAR_610
088A: actor 4@(31@,4i) perform_animation "gnstwall_injurd" IFP "SWAT" 8.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 disable_force 0 disable_lockZ 1
jump @WAR_700

:WAR_610
088A: actor 4@(31@,4i) perform_animation "Sweet_injuredloop" IFP "SWEET" 8.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 disable_force 0 disable_lockZ 1

:WAR_700
31@ += 1
if
31@ >= 4
jf @WAR_200
31@ = 0
jump @WAR_200

:WAR_1000
wait 0
if
$WAR_WarStatus == 0
jf @WAR_200
31@ = 0
30@ = 0

:WAR_1100
if
056D:   actor 4@(31@,4i) defined
jf @WAR_1200
actor.DestroyInstantly(4@(31@,5i))

:WAR_1200
31@ += 1
if
31@ >= 4
jf @WAR_1100
31@ = 0

:WAR_1300
if
056D:   actor 0@(30@,4i) defined
jf @WAR_1400
actor.DestroyInstantly(0@(30@,4i))

:WAR_1400
30@ += 1
if
30@ >= 4
jf @WAR_1300
30@ = 0
jump @WAR_1000