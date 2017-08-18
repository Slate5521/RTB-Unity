
// Debris "spark" explosion
datablock ParticleData(volcDebrisSpark)
{
	textureName			 = "~/data/particles/fire";
	dragCoefficient		= 0;
	gravityCoefficient	= 0.0;
	windCoefficient		= 0;
	inheritedVelFactor	= 0.5;
	constantAcceleration = 0.0;
	lifetimeMS			  = 500;
	lifetimeVarianceMS	= 50;
	spinRandomMin = -90.0;
	spinRandomMax =  90.0;
	useInvAlpha	= false;

	colors[0]	  = "0.8 0.2 0 1.0";
	colors[1]	  = "0.8 0.2 0 1.0";
	colors[2]	  = "0 0 0 0.0";

	sizes[0]		= 8;
	sizes[1]		= 1;
	sizes[2]		= 0.1;

	times[0]		= 0.0;
	times[1]		= 0.5;
	times[2]		= 1.0;
};

datablock ParticleEmitterData(volcDebrisSparkEmitter)
{
	ejectionPeriodMS = 20;
	periodVarianceMS = 0;
	ejectionVelocity = 0.5;
	velocityVariance = 0.25;
	ejectionOffset	= 0.0;
	thetaMin			= 0;
	thetaMax			= 90;
	phiReferenceVel  = 0;
	phiVariance		= 360;
	overrideAdvances = false;
	orientParticles  = false;
	lifetimeMS		 = 300;
	particles = "volcDebrisSpark";
};

datablock ExplosionData(volcDebrisExplosion)
{
	emitter[0] = volcDebrisSparkEmitter;

	// Turned off..
	shakeCamera = false;
	impulseRadius = 0;
	lightStartRadius = 0;
	lightEndRadius = 0;
};

// Debris smoke trail
datablock ParticleData(volcDebrisTrail)
{
	textureName			 = "~/data/particles/smoke";
	dragCoefficient		= 1;
	gravityCoefficient	= 0;
	inheritedVelFactor	= 0;
	windCoefficient		= 0;
	constantAcceleration = 0;
	lifetimeMS			  = 800;
	lifetimeVarianceMS	= 100;
	spinSpeed	  = 0;
	spinRandomMin = -90.0;
	spinRandomMax =  90.0;
	useInvAlpha	= false;

	colors[0]	  = "0.8 0.3 0.0 1.0";
	colors[1]	  = "0.1 0.1 0.1 0.7";
	colors[2]	  = "0.1 0.1 0.1 0.0";

	sizes[0]		= 5;
	sizes[1]		= 4;
	sizes[2]		= 0.01;

	times[0]		= 0.1;
	times[1]		= 0.2;
	times[2]		= 1.0;
};

datablock ParticleEmitterData(volcDebrisTrailEmitter)
{
	ejectionPeriodMS = 30;
	periodVarianceMS = 0;
	ejectionVelocity = 0.0;
	velocityVariance = 0.0;
	ejectionOffset	= 0.0;
	thetaMin			= 170;
	thetaMax			= 180;
	phiReferenceVel  = 0;
	phiVariance		= 360;
	//overrideAdvances = false;
	//orientParticles  = true;
	lifetimeMS		 = 20000;
	particles = "volcDebrisTrail";
};

// Debris object
datablock DebrisData(volcExplosionDebris)
{
	shapeFile = "~/data/shapes/debris.dts";
	emitters = "volcDebrisTrailEmitter";
	explosion = volcDebrisExplosion;
	
	elasticity = 0.6;
	friction = 0.5;
	numBounces = 0;
	bounceVariance = 1;
	explodeOnMaxBounce = true;
	staticOnMaxBounce = false;
	snapOnMaxBounce = false;
	minSpinSpeed = 0;
	maxSpinSpeed = 700;
	render2D = false;
	lifetime = 20;
	lifetimeVariance = 0.4;
	velocity = 40;
	velocityVariance = 10;
	fade = false;
	useRadiusMass = true;
	baseRadius = 0.3;
	gravModifier = 1;
	terminalVelocity = 50;
	ignoreWater = true;
};




datablock ParticleData(volcanoerupt) 
{ 
	textureName = "~/data/particles/smoke"; 
	dragCoeffiecient = 0.0; 
	gravityCoefficient = 1; 
	inheritedVelFactor = 0.00; 
	lifetimeMS = 12000; 
	lifetimeVarianceMS = 500; 
	useInvAlpha = true; 
	spinRandomMin = -10.0; 
	spinRandomMax = 10.0; 

	colors[0] = "1 0.5 0 0.2"; 
	colors[1] = "1 0.5 0 0.1"; 
	colors[2] = "1 0.5 0 0.01"; 

	sizes[0] = 20 / 1.25; 
	sizes[1] = 28.5 / 1.25; 
	sizes[2] = 0.01; 

	times[0] = 0.5; 
	times[1] = 0.9; 
	times[2] = 1.0;  
}; 

datablock ParticleEmitterData(volcanoeruptEmitter) 
{ 
	ejectionPeriodMS = 10; 
	periodVarianceMS = 5; 

	ejectionVelocity = 80; 
	velocityVariance = 2; 

	thetaMin = 0; 
	thetaMax = 50.0; 

	particles = volcanoerupt; 
};




datablock ExplosionData(volcExplosion)
{
	//explosionShape = "";
	//soundProfile = fw1ExplosionSound;

	lifeTimeMS = 20000;

	particleEmitter = volcanoeruptEmitter;
	particleDensity = 100;
	particleRadius = 500;
	Emitter = volcanoeruptEmitter;

	faceViewer	  = true;
	explosionScale = "1 1 1";

	debris = volcExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 100;
	debrisNumVariance = 2;
	debrisVelocity = 100;
	debrisVelocityVariance = 0.5;

	shakeCamera = true;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10.0;

	// Dynamic light
	lightStartRadius = 1;
	lightEndRadius = 20;
	lightStartColor = "1 0 0";
	lightEndColor = "1 1 0";
};


datablock ParticleData(volcano) 
{ 
	textureName = "~/data/particles/cloud"; 
	dragCoeffiecient = 0.0; 
	gravityCoefficient = -0.6; 
	inheritedVelFactor = 0.00; 
	lifetimeMS = 7000; 
	lifetimeVarianceMS = 500; 
	useInvAlpha = false; 
	spinRandomMin = -10.0; 
	spinRandomMax = 10.0; 

	colors[0] = "1 1 1 0.2"; 
	colors[1] = "1 1 1 0.1"; 
	colors[2] = "0 0 0 0.1"; 

	sizes[0] = 20; 
	sizes[1] = 28.5; 
	sizes[2] = 20;

	times[0] = 0.3; 
	times[1] = 0.8; 
	times[2] = 0.9;  
}; 

datablock ProjectileData(volcanoProjectile)
{
//	projectileShapeName = "~/data/shapes/bricks/a_briks/cylinder1x1f.dts";
	directDamage		  = 1000;
	radiusDamage		  = 1000;
	damageRadius		  = 1;
	explosion			  = volcExplosion;
//	particleEmitter	  = FWRocket1TrailEmitter;

	muzzleVelocity		= 25;
	velInheritFactor	 = 1;

	armingDelay			= 0;
	lifetime				= 20000;
	fadeDelay			  = 19500;
	bounceElasticity	 = 0.8;
	bounceFriction		= 0.1;
	isBallistic			= true;
	gravityMod = 0.0;

	hasLight	 = true;
	lightRadius = 20;
	lightColor  = "1 0 0 1.0";
};

datablock ParticleEmitterData(volcanoEmitter) 
{ 
	ejectionPeriodMS = 10; 
	periodVarianceMS = 5; 

	ejectionVelocity = 4; 
	velocityVariance = 3; 

	thetaMin = 0; 
	thetaMax = 50.0; 

	particles = volcano; 
};